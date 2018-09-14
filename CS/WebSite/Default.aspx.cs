using System;
using System.Web;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web;
using System.Collections.Generic;
using DevExpress.Web.Data;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page {
    public List<GridDataModel> dataSource {
        get {
            if (HttpContext.Current.Session["gridData"] == null)
                HttpContext.Current.Session["gridData"] = GridDataHelper.GetData();
            return (List<GridDataModel>)HttpContext.Current.Session["gridData"];
        }
        set {
            HttpContext.Current.Session["gridData"] = value;
        }
    }
    protected void Page_Init(object sender, EventArgs e) {
        grid.DataSource = dataSource;
        grid.DataBind();
    }

    protected void grid1_RowUpdating(object sender, ASPxDataUpdatingEventArgs e) {
        GridDataHelper.UpdateRow(e.Keys, e.NewValues, dataSource);
        CancelEdit(sender as ASPxGridView, e);
    }

    protected void grid_RowDeleting(object sender, ASPxDataDeletingEventArgs e) {
        GridDataHelper.DeleteRow(e.Keys, dataSource);
        CancelEdit(sender as ASPxGridView, e);
    }

    protected void grid_RowInserting(object sender, ASPxDataInsertingEventArgs e) {
        GridDataHelper.InsertRow(e.NewValues, dataSource);
        CancelEdit(sender as ASPxGridView, e);
    }
    protected void CancelEdit(ASPxGridView grid, CancelEventArgs e) {
        grid.CancelEdit();
        e.Cancel = true;
    }
}
