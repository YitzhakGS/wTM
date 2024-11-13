<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="AppWTM.ListarUsuarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href=" https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.min.css " rel="stylesheet">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <hr />
        <div class="container">
                <asp:GridView ID="grdListDenuncias" CssClass="table table-hover" runat="server" OnRowCommand="grdDenuncias_RowCommand" OnRowDataBound="grdListDenuncias_RowDataBound">
                    <Columns>
                         <asp:TemplateField>
                             <ItemTemplate>
                                 <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="eliminar">
                                     <i class="bi bi-trash-fill"></i>
                                 </asp:LinkButton>
                             </ItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField>
                          <ItemTemplate>
                              <asp:LinkButton ID="lnkEditar" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="editar">
                                  <i class="bi bi-pencil-fill"></i>
                              </asp:LinkButton>
                          </ItemTemplate>
                         </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        <asp:LinkButton ID="btnEliminar" runat="server" OnClick="BtnEliminar_Click" style="display:none;">Eliminar</asp:LinkButton>
        <input type="hidden" id="confirmado" name="confirmado" value="false" />
    </main>
    <script src=" https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.all.min.js "></script>
</asp:Content>
