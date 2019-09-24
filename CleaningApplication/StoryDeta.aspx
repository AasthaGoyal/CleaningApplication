<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="StoryDeta.aspx.cs" Inherits="CleaningApplication.WebForm27" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Image ID="img1" height="400px" width="400px" runat="server" />
        <br />
        <dx:ASPxImageSlider ID="ASPxImageSlider1" runat="server" ClientInstanceName="ImageSlider"
        EnableViewState="False" EnableTheming="False" NavigateUrlFormatString="javascript:void({0});">
        <SettingsImageArea ImageSizeMode="ActualSizeOrFit" NavigationButtonVisibility="None"
            ItemTextVisibility="Always" EnableLoopNavigation="true" />
        <SettingsNavigationBar Mode="Dots" />
        <SettingsSlideShow AutoPlay="true" StopPlayingWhenPaging="false" PausePlayingWhenMouseOver="false" PlayPauseButtonVisibility="Faded" />
        <Items>
            <dx:ImageSliderItem ImageUrl="~/Content/Images/widescreen/woman-using-laptop.jpg" NavigateUrl="1">
              
            </dx:ImageSliderItem>
              </Items>
        <Styles>
            <ImageArea Width="800" Height="313" />
        </Styles>
    </dx:ASPxImageSlider>
    </form>
</asp:Content>
