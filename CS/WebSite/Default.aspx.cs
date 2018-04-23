using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ddE_Init(object sender, EventArgs e)
    {
        ASPxDropDownEdit dropdownedit = sender as ASPxDropDownEdit;
        ASPxGridView grid = dropdownedit.NamingContainer.NamingContainer as ASPxGridView;

        string key = grid.UniqueID;
        string visibleIndex = (dropdownedit.NamingContainer as GridViewDataItemTemplateContainer).VisibleIndex + key;
        dropdownedit.ClientInstanceName = "dde" + visibleIndex;

        dropdownedit.ClientSideEvents.DropDown =
            String.Format("function(s,e) {{ SynchronizeGridValues(s, e, grid{0});}}", visibleIndex);

        dropdownedit.ClientSideEvents.TextChanged =
            String.Format("function(s,e) {{SynchronizeGridValues(s, e, grid{0});}}", visibleIndex);   
    }
    protected void btn_Init(object sender, EventArgs e)
    {
        ASPxButton button = sender as ASPxButton;
        ASPxGridView grid = button.NamingContainer.NamingContainer.NamingContainer.NamingContainer.NamingContainer as ASPxGridView;

        string key = grid.UniqueID;
        string visibleIndex = (button.NamingContainer.NamingContainer.NamingContainer.NamingContainer as GridViewDataItemTemplateContainer).VisibleIndex + key;

        button.ClientSideEvents.Click = String.Format("function(s, e){{dde{0}.HideDropDown();}}", visibleIndex);
    }
    protected void grid_Init(object sender, EventArgs e)
    {
        ASPxGridView curGrid = sender as ASPxGridView;
        ASPxGridView grid = curGrid.NamingContainer.NamingContainer.NamingContainer.NamingContainer.NamingContainer as ASPxGridView;

        string key = grid.UniqueID;
        string visibleIndex = (curGrid.NamingContainer.NamingContainer.NamingContainer.NamingContainer as GridViewDataItemTemplateContainer).VisibleIndex + key;
        curGrid.ClientInstanceName = "grid" + visibleIndex;

        curGrid.ClientSideEvents.SelectionChanged =
            String.Format("function(s,e) {{ OnGridSelectionChanged(s, e, dde{0});}}", visibleIndex);
    }
}
