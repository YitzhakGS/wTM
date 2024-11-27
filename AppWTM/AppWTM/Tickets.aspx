<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="AppWTM.Tickets" %>
<asp:Content ID="Tickets" ContentPlaceHolderID="MainContent" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@sweetalert2/theme-dark/dark.css">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">

    <div class="container mt-4">
    <div class="row">
        <!-- Columna del DataGrid -->
        <div class="col-md-8">
            <asp:Label ID="lblMisTickets" runat="server" Text="Mis Tickets" CssClass="h4 mb-3 d-block"></asp:Label>
            <div class="table-responsive">
                <asp:GridView ID="dgrTickets" runat="server" CssClass="table table-hover"></asp:GridView>
            </div>
        </div>

        <!-- Columna del Botón -->
        <div class="col-md-4 d-flex align-items-start justify-content-center">
            <button type="button" class="btn btn-primary mt-2 w-75" data-bs-toggle="modal" data-bs-target="#crearTicketModal">Crear Ticket</button>
        </div>
    </div>
</div>

    <div class="modal fade" id="crearTicketModal" tabindex="-1" aria-labelledby="crearTicketModalLabel" aria-hidden="true">
        <div class="modal-dialog <%--modal-lg--%>" style="max-width: 45%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="crearTicketModalLabel">Crear Nuevo Ticket</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Contenido del formulario dentro del modal -->
                    <main aria-labelledby="title">
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-12 mx-auto">
                                    <div>
                                        <div class="card-header text-black text-center">
                                            <h4>Envíe una nueva solicitud</h4>
                                        </div>
                                        <div class="card-body row mt-1">
                                            <div class="col-12 mb-2">
                                                <label for="txtTitulo" class="form-label">Título de la Solicitud</label>
                                                <div class="row">
                                                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control mx-auto" placeholder="Título de la solicitud" style="width: 90%;"></asp:TextBox>
                                                    <small class="form-text text-muted" style="text-align: left; margin-left: 3rem;">Máx. 50 caracteres</small>
                                                </div>
                                            </div>
                                            <div class="mt-1">
                                                <label for="ddlArea" class="form-label">Área o Departamento</label>
                                                <div class="row">
                                                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-select mx-auto" style="width: 90%;"></asp:DropDownList>
                                                </div>
                                            </div>
                                            <%--<div class="mt-1">
                                                <label for="ddlPrioridad" class="form-label mt-1">Prioridad</label>
                                                <div class="row">
                                                    <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="form-select mx-auto" style="width: 90%;"></asp:DropDownList>
                                                </div>
                                            </div>--%>
                                            <div class="mt-1">
                                                <label for="txtDescripcion" class="form-label mt-1">Descripción</label>
                                                <div class="row">
                                                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control mx-auto" placeholder="Describa los detalles de su solicitud" style="width: 90%; text-align: left;" rows="4"></asp:TextBox>
                                                    <small class="form-text text-muted" style="text-align: left; margin-left: 3rem;">Sea específico</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                            <div style="display: flex; justify-content: center; gap: 15px;">
                                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar"  style="width: 120px;" OnClick="btnCancelar_Click"/>
                                                <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" Text="Enviar"  style="width: 120px;" OnClick="btnEnviar_Click"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </main>
                </div>
            </div>
        </div>
    </div>

<script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.all.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
