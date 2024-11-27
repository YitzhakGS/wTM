<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="AppWTM.EditarPerfil" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.min.css" rel="stylesheet">
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <main aria-labelledby="Editar Perfil">
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
            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="ContactNumber" class="form-label">Número de Contacto</label>
            <asp:TextBox ID="txtTelefono" CssClass="form-control w-100" runat="server" required placeholder="Número de Contacto"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label id="lblPassword" runat="server" for="Password" class="form-label">Contraseña</label>
            <asp:TextBox ID="txtPassword" CssClass="form-control w-100" runat="server" TextMode="Password" required placeholder="Contraseña"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="Estado" class="form-label">Estado</label>
            <asp:DropDownList ID="drpEstado" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione un estado" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Activo"></asp:ListItem>
                <asp:ListItem Text="Inactivo"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="drpRol" class="form-label">Rol</label>
            <asp:DropDownList ID="drpRol" runat="server" CssClass="form-control">
                <asp:ListItem Text="Selecciona un rol" Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Usuario"></asp:ListItem>
                <asp:ListItem Text="Agente"></asp:ListItem>
                <asp:ListItem Text="Administrador"></asp:ListItem>
                <asp:ListItem Text="Asignador de tickets" Value="4"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="button-container mt-4">
            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancelar"/>
            <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar"/>
        </div>
    </div>
    </main>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.14.3/dist/sweetalert2.all.min.js"></script>
</asp:Content>