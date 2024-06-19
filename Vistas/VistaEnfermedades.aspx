<%@ Page Title="Administracion de Enfermedades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VistaEnfermedades.aspx.cs" Inherits="ExpedienteMedico.VistaEnfermedades" %>

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
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Enfermedades</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar una nueva enfermedad</h2>
                    <form id="formMedico" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtEnfermedadId">Enfermedad Id :</label>
                                    <input type="text" class="form-control" id="txtEnfermedadId" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtNombreEnf">Nombre de la Enfermedad :</label>
                                    <input type="text" class="form-control" id="txtNombreEnf" runat="server" />
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="txtSintomas">Sintomas :</label>
                                    <input type="text" class="form-control" id="txtSintomas" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtCodigoOMS">CodigoOMS :</label>
                                    <input type="text" class="form-control" id="txtCodigoOMS" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label for="txtPaises">Paises :</label>
                                    <input type="text" class="form-control" id="txtPaises" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="txtTratamiento">Tratamiento:</label>
                                <input type="text" class="form-control" id="txtTratamiento" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="txtDescubridor">Descubridor:</label>
                                <input type="text" class="form-control" id="txtDescubridor" runat="server" />
                            </div>
                        </div>
                </div>
                <button type="submit" class="btn btn-primary" onserverclick="GuardarEnfermedad" runat="server">Guardar Enfermedad</button>
                <div id="divAlerta" runat="server" class="alert alert-danger">
                    Debe llenar todos los campos para guardar la enfermedad.
                </div>
                </form>

            </div>
            <!-- /.container-fluid -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Lista de Enfermedades</h6>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                            <thead>
                                <tr>
                                    <th>EnfermedadId</th>
                                    <th>NombreEnf</th>
                                    <th>Sintomas</th>
                                    <th>CodigoOMS</th>
                                    <th>Paises</th>
                                    <th>Tratamiento</th>
                                    <th>Descubridor</th>

                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>EnfermedadId</th>
                                    <th>NombreEnf</th>
                                    <th>Sintomas</th>
                                    <th>CodigoOMS</th>
                                    <th>Paises</th>
                                    <th>Tratamiento</th>
                                    <th>Descubridor</th>
                                </tr>
                            </tfoot>
                            <tbody runat="server" id="tablaEnfermedades">
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
