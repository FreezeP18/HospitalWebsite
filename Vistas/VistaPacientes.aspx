<%@ Page Title="Administracion de Pacientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaPacientes.aspx.cs" Inherits="ExpedienteMedico.VistaPacientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">
            <!-- Sidebar - Brand -->
            <a class="sidebar-brand d-flex align-items-center justify-content-center" href="Dashboard.aspx">
                <div class="sidebar-brand-icon rotate-n-15">
                    <i class="fas fa-laugh-wink"></i>
                </div>
                <div class="sidebar-brand-text mx-3">Expediente Medico</div>
            </a>

            <!-- Divider -->
            <hr class="sidebar-divider my-0">

            <!-- Nav Item - Dashboard -->
            <li class="nav-item">
                <a class="nav-link" href="Dashboard.aspx">
                    <i class="fas fa-fw fa-tachometer-alt"></i>
                    <span>Dashboard</span></a>
            </li>
            <!-- Divider -->
            <div id="menuMedicos" runat="server">
                <hr class="sidebar-divider">
                <li class="nav-item">
                    <a class="nav-link" href="VistaMedicos.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Medicos</span></a>
                </li>
            </div>

            <div id="menuMedicamentos" runat="server">
                <hr class="sidebar-divider">
                <li class="nav-item">
                    <a class="nav-link" href="VistaMedicamentos.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Medicamentos</span></a>
                </li>
            </div>

            <div id="menuEnfermedades" runat="server">
                <hr class="sidebar-divider">
                <li class="nav-item">
                    <a class="nav-link" href="VistaEnfermedades.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Enfermedades</span></a>
                </li>
            </div>

            <div id="menuPacientes" runat="server">
                <hr class="sidebar-divider">
                <li class="nav-item">
                    <a class="nav-link" href="VistaPacientes.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Pacientes</span></a>
                </li>
            </div>

            <div id="menuCitas" runat="server">
                <hr class="sidebar-divider">
                <li class="nav-item">
                    <a class="nav-link" href="VistaCitas.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Citas</span></a>
                </li>
            </div>

        </ul>
        <!-- End of Sidebar -->

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Begin Page Content -->
                <div class="container-fluid">
                    <!-- Page Heading -->
                    <div class="d-sm-flex align-items-center justify-content-between mb-4">
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Pacientes</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nuevo Paciente</h2>
                    <form id="formMedico" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtNombre">Nombre:</label>
                                    <input type="text" class="form-control" id="txtNombre" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtApellidos">Apellidos:</label>
                                    <input type="text" class="form-control" id="txtApellidos" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtIdentificacion">Identificación:</label>
                                    <input type="text" class="form-control" id="txtIdentificacion" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="ddlTipoIdentificacion">Tipo de Identificación:</label>
                                    <select class="form-control" id="ddlTipoIdentificacion" runat="server">
                                        <option value="Cédula">Cédula</option>
                                        <option value="Pasaporte">Pasaporte</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlGenero">Genero:</label>
                                    <select class="form-control" id="ddlGenero" runat="server">
                                        <option value="Hombre">Hombre</option>
                                        <option value="Mujer">Mujer</option>
                                    </select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="ddlEstadoCivil">Estado Civil:</label>
                                    <select class="form-control" id="ddlEstadoCivil" runat="server"></select>
                                </div>
                                <div class="form-group">
                                    <label for="txtNacionalidad">Nacionalidad:</label>
                                    <input type="text" class="form-control" id="txtNacionalidad" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtFechaNacimiento">Fecha de nacimiento:</label>
                                    <input type="date" class="form-control" id="txtFechaNacimiento" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtLugarResidencia">Lugar de Residencia:</label>
                                    <input type="text" class="form-control" id="txtLugarResidencia" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtTelefono">Telefono:</label>
                                    <input type="text" class="form-control" id="txtTelefono" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtCorreo">Correo:</label>
                                    <input type="text" class="form-control" id="txtCorreo" runat="server" />
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btn btn-primary" onserverclick="GuardarPaciente" runat="server">Guardar Paciente</button>
                        <div id="divAlerta" runat="server" class="alert alert-danger">
                            Debe llenar todos los campos para crear un paciente.
                        </div>
                    </form>

                </div>
                <!-- /.container-fluid -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Lista de Pacientes</h6>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Apellidos</th>
                                        <th>Identificacion</th>
                                        <th>Tipo de Identificacion</th>
                                        <th>Genero</th>
                                        <th>Estado Civil</th>
                                        <th>Nacionalidad</th>
                                        <th>FechaNacimiento</th>
                                        <th>LugarResidencia</th>
                                        <th>Telefono</th>
                                        <th>Correo</th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Apellidos</th>
                                        <th>Identificacion</th>
                                        <th>Tipo de Identificacion</th>
                                        <th>Genero</th>
                                        <th>Estado Civil</th>
                                        <th>Nacionalidad</th>
                                        <th>FechaNacimiento</th>
                                        <th>LugarResidencia</th>
                                        <th>Telefono</th>
                                        <th>Correo</th>
                                    </tr>
                                </tfoot>
                                <tbody runat="server" id="tablaPacientes">
                                    <!-- Aquí se agregarán las filas dinámicamente -->
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <!-- End of Main Content -->
            </div>
            <!-- End of Content Wrapper -->

        </div>
        <!-- End of Page Wrapper -->
        <script src="/Scripts/jquery.dataTables.min.js"></script>
        <script src="/Scripts/dataTables.bootstrap4.min.js"></script>
        <script>
            $(document).ready(function () {
                $('#dataTable').DataTable();
            });
        </script>
</asp:Content>
