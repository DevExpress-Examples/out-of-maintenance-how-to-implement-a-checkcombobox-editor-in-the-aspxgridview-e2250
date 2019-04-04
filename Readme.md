<!-- default file list -->
*Files to look at*:

* [Solution.sln](./CS/Solution.sln)
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement a CheckComboBox editor in the ASPxGridView


<p>This example is based on the <a href="http://demos.devexpress.com/ASPxEditorsDemos/ASPxDropDownEdit/CheckComboBox.aspx">CheckComboBox Emulation demo</a>. It illustrates how to use a combination of the ASPxDropDownEdit and ASPxGridView to emulate a checked combo box that allows end-users to select multiple items within its dropdown list.</p><p>In this example, a template of the DropDownWindowTemplate type is created within the ASPxDropDownEdit. This template contains an instance of the ASPxGridView whose ShowSelectCheckbox property is set to true. The ASPxDropDownEdit's Text property stores a list, containing selected items (values, in this scenario). In addition to selecting items within the dropdown list, this example allows end-users to select items by entering a semicolon-separated series of item values into the ASPxDropDownEdit's edit box. If an item text that doesn't exist is entered, it is deleted from the edit box.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2203">CheckComboBox filtering in the Auto Filter Row</a></p>

<br/>


