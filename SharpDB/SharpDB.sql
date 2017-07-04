
---------------------------Database----------------------------------------

create database SharpDB
go

use SharpDB

go


-----------------------------Table-------------------------------------------

 create table TestType
 (
 ID int identity constraint PK_Type_ID primary key,
 typeName varchar(50) not null
 )



 
 go


 create table TestSetUp
 (
 ID int identity constraint PK_Test_ID primary key,
 testName varchar(50) not null,
 testFee money not null,
 typeID int constraint FK_Test_Type_ID  foreign key references TestType

 )

 go
   

 create table Patient
 (
 ID int identity constraint PK_Patient_ID primary key,
 patientName varchar(50) not null,
 DateOfBirth datetime,
 MobileNO int not null,
 BillNo nvarchar(250) not null constraint UQ_Patient_BillNo unique,
 BillDate date not null,
 TotalFee money,
 PaidBill money

 )

 go
 create table PatientRequestTest
 ( ID int identity primary key,
   patientID int constraint FK_TestRequest_PatientID foreign key  references Patient,
   TestID int constraint FK_TestRequest_TestID  foreign key references TestSetup
 )




         

 --------------------------------------View--------------------------------------------

 go
   create view VW_TestDetails 
   as
   select test.testName as [Test],test.testFee as Fee,typ.typeName as [Type] 
	        from TestType  typ 
            join TestSetUp  test on typ.ID = test.typeID


   --------------------------------------Store Procedure----------------------------------------
 
 go
 Create proc SP_PatientPaymentByBillNo
		 @billNo varchar(250)
		 as 
		 begin
		 select test.testName testName,test.testFee as testFee,p.BillDate as BillDate,p.BillNo as BillNo,
		        p.TotalFee as TotalFee,p.PaidBill as PaidBill 
		        from PatientRequestTest req join Patient p
		        on req.patientID=p.ID
				join TestSetUp test
				on req.TestID=test.ID where p.BillNo=@billNo

        end 





 go
create proc Sp_PatientDetailsUpdate
		@BillNo varchar(250),
		@PaidBill money
		as
		begin
		update Patient set PaidBill=case 
		                            when(TotalFee-PaidBill)=0 and @PaidBill>TotalFee then PaidBill
		                            when @PaidBill>TotalFee and @PaidBill>PaidBill then PaidBill
									when @PaidBill>TotalFee then 0
									when @PaidBill> TotalFee-PaidBill then PaidBill
									when (TotalFee-PaidBill)=0 then TotalFee
									when TotalFee=@PaidBill then TotalFee
									when (TotalFee-PaidBill)=@PaidBill then TotalFee
									else
									PaidBill+@PaidBill
									end
       where BillNo=@BillNo
		end 
								


go


create proc sp_GetReportByTest
 @FromDate datetime ,
 @ToDate datetime
 as
 begin	
select test.testName, coalesce(sum(myTable.TestCount),0) as TotalTest, coalesce(sum(myTable.Amount),0) as TotalAmount from TestSetUp test 
left join
(
   select req.TestID ,count(req.TestID) as TestCount,sum(test.testFee) as Amount from TestSetUp test 
        join PatientRequestTest req 
       on test.ID=req.TestID
	    join Patient patient 
	    on req.patientID=patient.ID
		where BillDate>=@FromDate  and BillDate<= @ToDate
		group by req.TestID
		) as myTable

on test.ID=myTable.TestID

group by test.testName

end



go
	   
	create proc sp_GetReportByType

	@FromDate datetime ,
    @ToDate datetime   
    as
    begin
	
	select  typ.typeName,coalesce(sum(myTable.TotalNoOfTest) ,0) as totalTest, 
	        Coalesce(sum(myTable.testTotal),0) as TotalAmount 
	        from TestType typ left join

    (select test.typeID,sum(testFee) as testTotal ,count(test.ID) as TotalNoOfTest   
	           from  PatientRequestTest req join TestSetUp test
               on req.TestID=test.ID
		       join Patient patient 
		       on req.patientID=patient.ID
		       where BillDate>=@FromDate  and BillDate<= @ToDate
		       group by test.typeID
		   )   as myTable

		       on typ.ID=myTable.typeID
		       group by typ.typeName
		    
		   end


		   go




 create proc sp_UnPaidBillReport
 @FromDate datetime,
 @ToDate datetime
 as
 begin

  select   p.BillNo as BillNo, p.MobileNO as MobileNo,p.patientName as PatientName,
           (p.TotalFee-p.PaidBill) as UnPaidBill
           from Patient p
           where  (p.TotalFee-p.PaidBill)!= 0 and BillDate>=@FromDate  and BillDate<= @ToDate

 end



    select * from Patient    

	select * from TestType

	select * from TestSetUp

	select * from PatientRequestTest
