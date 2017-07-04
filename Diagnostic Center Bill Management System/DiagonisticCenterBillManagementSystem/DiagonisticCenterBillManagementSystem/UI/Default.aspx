<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteView.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DiagonisticCenterBillManagementSystem.UI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpMainContent" runat="server">

   <div class="jumbotron">
         <h2 style="color:red;text-align:center">Daignostic Center Management System</h2><br />
  <br/>
  <div id="myCarousel" class="carousel slide" data-ride="carousel">
    <!-- Indicators -->
    <ol class="carousel-indicators">
      <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
      <li data-target="#myCarousel" data-slide-to="1"></li>
      <li data-target="#myCarousel" data-slide-to="2"></li>
      <li data-target="#myCarousel" data-slide-to="3"></li>
      <li data-target="#myCarousel" data-slide-to="4"></li>
    </ol>

    <!-- Wrapper for slides -->
    <div class="carousel-inner" role="listbox">
      <div class="item active">
        <img src="../Images/img1.jpg" alt="img1" width="1060" height="600"/>
      </div>

      <div class="item">
        <img src="../Images/img4.png" alt="img4" width="1060" height="600"/>
      </div>
      <div class="item">
        <img src="../Images/img8.png" alt="img8" width="1060" height="600"/>
      </div>
        <div class="item">
        <img src="../Images/img10.jpg" alt="img10" width="1060" height="600"/>
      </div>
        <div class="item">
        <img src="../Images/img 6.png" alt="img6" width="1060" height="600"/>
      </div>
    </div>

    <!-- Left and right controls -->
    <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
      <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
      <span class="sr-only">Previous</span>
    </a>
    <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
      <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
      <span class="sr-only">Next</span>
    </a>
  </div>
</div>

</asp:Content>
