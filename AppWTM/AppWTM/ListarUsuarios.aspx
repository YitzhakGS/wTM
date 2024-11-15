<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="AppWTM.ListarUsuarios" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.min.css" rel="stylesheet">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <main aria-labelledby="title">
        <h2 id="titulo"><%: Title %></h2>
        <hr />
        <asp:Button ID="btnRegModal" runat="server" CssClass="btn btn-primary" Text="Agregar Usuario" onClick="btnRegModal_Click" UseSubmitBehavior="false"/>
        <div class="container">
            <asp:GridView ID="grdListUsuarios" CssClass="table table-hover" runat="server" OnRowCommand="grdDenuncias_RowCommand" OnRowDataBound="grdListDenuncias_RowDataBound">
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
        <!-- Modal para Registrar Usuario -->
        <div class="modal fade" id="registroUsuarioModal" tabindex="-1" aria-labelledby="registroUsuarioLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="lblRegistrar" runat="server">Registrar Usuario</h5>
                        <h5 class="modal-title" id="lblActualizar" runat="server" visible="false">Actualizar Usuario</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <asp:PlaceHolder runat="server">
                            <asp:ValidationSummary ID="ValidationSummary1" CssClass="text-danger" runat="server" HeaderText="Errores:" />
                            <div class="container profile-container px-4 pb-4">
                                <div class="mb-3">
                                    <label for="Nombre" class="form-label">Nombre(s)</label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control w-100" runat="server" required placeholder="Nombre(s)"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="Apellidos" class="form-label">Apellidos</label>
                                    <asp:TextBox ID="txtApellidos" CssClass="form-control w-100" runat="server" required placeholder="Apellidos"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="CorreoElectronico" class="form-label">Correo Electrónico</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control w-100" runat="server" TextMode="Email" required placeholder="Correo Electrónico"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="Area" class="form-label">Área</label>
                                    <asp:DropDownList ID="drpArea" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="" Text="Selecciona tu área..." />
                                        <asp:ListItem Value="Mantenimiento" Text="Mantenimiento" />
                                        <asp:ListItem Value="Recursos materiales" Text="Recursos materiales" />
                                    </asp:DropDownList>
                                </div>

                                <div class="mb-3">
                                    <label for="ContactNumber" class="form-label">Número de Contacto</label>
                                    <asp:TextBox ID="txtTelefono" CssClass="form-control w-100" runat="server" required placeholder="Número de Contacto"></asp:TextBox>
                                </div>

                                <div class="mb-3">
                                    <label for="Password" class="form-label">Contraseña</label>
                                    <asp:TextBox ID="txtPassword" CssClass="form-control w-100" runat="server" TextMode="Password" required placeholder="Contraseña"></asp:TextBox>
                                </div>

                                <div class="button-container mt-4">
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" data-bs-dismiss="modal" Text="Cancelar"/>
                                    <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnRegistrar_Click"/>
                                    <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" onClick="btnActualizar_Click" Visible="false"/>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="btnHidden" runat="server" Style="display:none;" OnClientClick="AbrirModal();" />
    </main>
    <script type="text/javascript">
        function AbrirModal() {
            var modal = new bootstrap.Modal(document.getElementById('registroUsuarioModal'));
            modal.show();
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.all.min.js"></script>
</asp:Content>
