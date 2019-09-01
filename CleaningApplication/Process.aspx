<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Process.aspx.cs" Inherits="CleaningApplication.WebForm12" %>
<%@ MasterType VirtualPath="~/Home.Master" %> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">

   
    <section class="process-section" style="background-image:url(images/background/1.jpg)">
		<div class="top-layer"></div>
		<div class="auto-container">
			<!--Sec Title-->
			<div class="sec-title centered">
				<div class="icon-box">
					<span class="icon flaticon-broom"></span>
				</div>
				<h2>our Work Process</h2>
				<div class="separator"></div>
			</div>
			
			<!--Process Blocks-->
			<div class="process-blocks">
				<div class="clearfix row">
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInLeft" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon ">
									<img src="images/background/wp1.png" height="80px" width="80px" /></span>
							</div>
							<div class="number-line">
								<div class="number" >1</div>
							</div>
							<div class="text">
                                <asp:Label ID="lblhead1" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-brush-2"></span>
							</div>
							<div class="number-line">
								<div class="number">2</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead2" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInUp" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon ">
									<img src="images/background/w3.png" height="80px" width="80px"/>
								</span>
							</div>
							<div class="number-line">
								<div class="number">3</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead3" runat="server" ></asp:Label></div>
						</div>
					</div>
					
					<!--Process Block-->
					<div class="process-block col-lg-3 col-md-6 col-sm-12">
						<div class="inner-box wow fadeInRight" data-wow-delay="0ms" data-wow-duration="1500ms">
							<div class="icon-box">
								<span class="icon flaticon-spray-1">
									
								</span>
							</div>
							<div class="number-line">
								<div class="number">4</div>
							</div>
							<div class="text"> <asp:Label ID="lblhead4" runat="server" ></asp:Label></div>
						</div>
					</div>
					
				</div>
			</div>
		  </div>
        </section>
			
         <div class="container">
			<div class="row">
				<div class="col-xs-12">
					<div class="modal" id="quotemodal" >

		
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header" style="background-color:darkblue">
                    
	   
					<h4 class="modal-title" style="color: #FFFFFF"> Request Quote</h4>
					 <button class="close" data-dismiss="modal" style="color: #FFFFFF">&times;</button>
				</div>
				<div class="modal-body">
				
						<div class="form-group">
							<label for="name"> Full Name*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your name" type="text" id="nametxt" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Name is required" ControlToValidate="nametxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
						</div>
						<div class="form-group">
							 <label for="name"> Email Id</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your emailid"  id="emailidtxt" />

						</div>
						<div class="form-group">
							 <label for="name"> Phone No*</label>
							<asp:TextBox runat="server" class="form-control" placeholder="Enter your Contact No"  id="phonetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="* Phone is required" ControlToValidate="phonetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
						<div class="form-group">
							 <label for="name"> Message*</label>
							<asp:TextBox runat="server" height="70px" class="form-control" placeholder="Enter your message"  id="messagetxt" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="* Message is required" ControlToValidate="messagetxt" Font-Bold="True" ValidationGroup="requestQuote" ForeColor="#CC0000"></asp:RequiredFieldValidator>
					
						</div>
					

				</div>
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
				<div class="modal-footer">
					<asp:Label ID="messagelbl" runat="server" Font-Bold="True" ForeColor="#CC0000" ></asp:Label>
                    
	
					<asp:Button ID="btnConfirm" runat="server" ValidationGroup="requestQuote" Text="Confirm" class="btn btn-primary" OnClick="btnConfirm_Click"/>
					<%--<button id="btnConfirm" class="btn btn-primary" AutoPostBack="true" onclick="btnConfirm_onClick" >Submit</button>--%>
					<button class="btn btn-primary" data-dismiss ="modal"> Close</button>
				</div>
             </ContentTemplate>

		 <Triggers>
			 <asp:AsyncPostBackTrigger ControlID="btnConfirm" EventName="Click" />
		 </Triggers>
	</asp:UpdatePanel>
			</div>
		</div>
			</div>
		
				</div>
			</div>
		</div>
	
	<br />
        <div class="container form-control">

        
    <table id="tbprocess1" >
        <tr>
            <td colspan="2">
                
                      <h3 class="text-center"> Step 1: <asp:Label ID="lblname1" runat="server" ></asp:Label></h3>
                <br />
               
            </td>
        </tr>
        <tr>
            <td width="70%" class="text-center" > 
                <asp:Label ID="lblprocess1" runat="server" ></asp:Label>
                 </td>
            <td width="30%" rowspan="2"> <img  src="images/main-slider/pro1.png" class="float-center" width="300px" height="300px"/>
                    
            </td>
        </tr>
        <tr>
            <td>  <div class="form-group" style="text-align: right">

                  <asp:Button ID="btnProcess1" runat="server" class="btn-primary form-control theme-btn book-btn"  Text="Get a Quote" OnClick="btnProcess1_Click" /></div>
            
              </td>
        </tr>
       </table>

            <table id="tbprocess2">

        <tr>
             <td colspan="2">
                
                      <h3 class="text-center"> Step 2: <asp:Label ID="lblname2" runat="server" ></asp:Label></h3>
                
              
            </td>
        </tr>
        <tr>
              <td rowspan="2" width="40%"> <img  src="images/main-slider/pro2.jpg" class="float-left" width="350px" height="400px"/></td>
             <td width="60%" class="text-center" > 
                <asp:Label ID="lblProcess2" runat="server" ></asp:Label>
                 </td>
        </tr>
                <tr>
                     <td>  <div style="text-align: right">

                  <asp:Button ID="btnProcess2" runat="server" class="btn-primary form-control theme-btn book-btn"  Text="See all services" OnClick="btnProcess2_Click" /></div>
            
              </td>
                </tr>
                </table>

             <table width="100%" id="tbprocess3">
        <tr>
            <td colspan="2">
                
                      <h3 class="text-center"> Step 3: <asp:Label ID="lblname3" runat="server" ></asp:Label></h3>
                <br />
               
            </td>
        </tr>
        <tr>
            <td width="70%" class="text-center" > 
                <asp:Label ID="lblprocess3" runat="server" ></asp:Label>
                 </td>
            <td width="30%" rowspan="2"> <img  src="images/main-slider/pro3.png" class="float-center" width="300px" height="300px"/>
                    
            </td>
        </tr>
        <tr>
            <td>  <div class="form-group" style="text-align: right">

                  <asp:Button ID="btnProcess3" runat="server" class="btn-primary form-control theme-btn book-btn"  Text="Read more" OnClick="btnProcess3_Click" /></div>
            
              </td>
        </tr>
       </table>

            <%-- <table >

         <tr>
            <td colspan="2">
                
                      <h3 class="text-center"> Step 3: <asp:Label ID="lblname3" runat="server" ></asp:Label></h3>
                
            </td>
        </tr>
       <tr>
            <td width="70%" class="text-center" > 
                <asp:Label ID="lblprocess3" runat="server" ></asp:Label>
                 </td>
            <td width="30%" rowspan="2"> <img  src="images/main-slider/pro3.png" class="float-right" width="300px" height="300px"/></td>
        </tr>
               <tr>
                     <td>  <div class="form-group" style="text-align: right">

                  <asp:Button ID="btnProcess3" runat="server" class="btn-primary form-control theme-btn book-btn"  Text="Read more" /></div>
            
              </td>
                </tr>
                </table>--%>
              


            <table id="tbprocess4">
         <tr>
            
             <td colspan="2">
                
                      <h3 class="text-center"> Step 4: <asp:Label ID="lblname4" runat="server" ></asp:Label></h3>
                
              
            </td>
        </tr>
        <tr>
              <td width="40%" rowspan="2"> <img  src="images/main-slider/pro4.png" class="float-left" width="350px" height="300px"/></td>
             <td width="60%" class="text-center" > 
                <asp:Label ID="lblprocess4" runat="server" ></asp:Label>
                 </td>
        </tr>
                <tr>
                     <td>  <div class="form-group" style="text-align: right">

                  <asp:Button ID="btnProcess4" runat="server" class="btn-primary form-control theme-btn book-btn"  Text="Read our reviews" OnClick="btnProcess4_Click" /></div>
            
              </td>
                </tr>

    </table>
        </div>
    <br />
      
       
         </form>
</asp:Content>
