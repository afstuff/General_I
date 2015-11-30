<%@ Page Title="ABS:: Home" Language="C#" MasterPageFile="~/Site0.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ABSGeneral.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="Content/slides/slide1.jpg" />
            </div>

            <div class="item">
                <img src="Content/slides/slide2.jpg" />
            </div>

            <div class="item">
                <img src="Content/slides/slide1.jpg" />
            </div>

            <div class="item">
                <img src="Content/slides/slide2.jpg" />
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
    <p>
    </p>

    <div class="jumbotron">
        <h2>Experience the new ABS Solution for all your business task!
        </h2>
        <h4>Feature Include:</h4>
    </div>
    <div class="row">
        <div class="col-lg-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Getting Started</h3>
                </div>
                <div class="panel-body">
                    See details to get started!
                <br />
                    <button class="btn btn-info btn-sm">Click here</button>
                </div>
            </div>
        </div>

        <div class="col-lg-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Getting Started</h3>
                </div>
                <div class="panel-body">
                    See details to get started!
                <br />
                    <button class="btn btn-info btn-sm">Click here</button>
                </div>
            </div>
        </div>

        <div class="col-lg-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Getting Started</h3>
                </div>
                <div class="panel-body">
                    See Dashboard!
                <br />
                    <a href="#" class="btn btn-info btn-sm">Dashboard</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
