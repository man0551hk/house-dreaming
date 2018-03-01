<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="news" id="news">
		<div class="container">
			<h3 class="w3l_head">Latest Properties</h3>
			<p class="w3ls_head_para">see Our Properties</p>
			<div class="latest-agileits-grids">
			<div class="col-md-4 news-grid">
					<img src="images/4.jpg" alt="">
					<div class="news-grid-info">
						<h5><span>New</span> Property </h5>
						<h4>45,000</h4>
						<p>Etiam ex lorem cursus vitae placerat suscipit dapibus tortor sed nec augue</p>
						<div class="article-links">
							<ul>
								<li><a href="#"><i class="glyphicon glyphicon-heart-empty"></i><span>1,052</span></a></li>
								<li><a href="#"><i class="glyphicon glyphicon-comment"></i><span>10K</span></a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="col-md-4 news-grid">
					<img src="images/2.jpg" alt="">
					<div class="news-grid-info">
						<h5><span>New</span> Property </h5>
						<h4>50,000</h4>
						<p>Lorem cursus vitae placerat etiam ex suscipit dapibus tortor sed nec augue</p>
						<div class="article-links">
							<ul>
								<li><a href="#"><i class="glyphicon glyphicon-heart-empty"></i><span>1,052</span></a></li>
								<li><a href="#"><i class="glyphicon glyphicon-comment"></i><span>10K</span></a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="col-md-4 news-grid">
					<img src="images/5.jpg" alt="">
					<div class="news-grid-info">
						<h5><span>New</span> Property </h5>
						<h4>60,000</h4>
						<p>Etiam ex lorem cursus vitae placerat suscipit dapibus tortor sed nec augue</p>
						<div class="article-links">
							<ul>
								<li><a href="#"><i class="glyphicon glyphicon-heart-empty"></i><span>1,052</span></a></li>
								<li><a href="#"><i class="glyphicon glyphicon-comment"></i><span>10K</span></a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="clearfix"> </div>
			</div>
		</div>
	</div>
</asp:Content>

