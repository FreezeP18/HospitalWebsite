<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VistaCitas.aspx.cs" Inherits="ExpedienteMedico.VistaCitas" %>

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
                        <h1 class="h3 mb-0 text-gray-800">Administracion de Citas Medicas</h1>
                    </div>
                </div>
                <div class="container">
                    <h2>Agregar Nueva Informacion</h2>
                    <form id="formMedico" class="needs-validation" novalidate>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="ddlPacientes">Pacientes:</label>
                                    <select class="form-control" id="ddlPacientes" runat="server"></select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="ddlMedico">Medico:</label>
                                    <select class="form-control" id="ddlMedico" runat="server"></select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlEnfermedades">Enfermedades:</label>
                                    <select class="form-control" id="ddlEnfermedades" runat="server"></select>
                                </div>
                                <div class="form-group">
                                    <label for="ddlMedicamentoRecetado">Medicamento recetado:</label>
                                    <select class="form-control" id="ddlMedicamentoRecetado" runat="server"></select>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtFechaDiagnostico">Fecha de diagnostico:</label>
                                    <input type="date" class="form-control" id="txtFechaDiagnostico" runat="server" />
                                </div>
                                <button type="submit" class="btn btn-primary" onserverclick="GuardarCita" runat="server">Guardar Info</button>
                                <div id="divAlerta" runat="server" class="alert alert-success">
                                    Debe llenar todos los campos para crear un medico.
                                </div>
                            </div>
                       
                    </form>
                </div>
            </div>
        </div>


        <!-- /.container-fluid -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Lista de Citas</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Identificacion Paciente</th>
                                <th>Nombre Paciente</th>
                                <th>Apellidos Paciente</th>
                                <th>Nombre Medico</th>
                                <th>Apellidos Medico</th>
                                <th>Especialidad Medico</th>
                                <th>Nombre Enfermedad</th>
                                <th>Sintomas Enfermedad</th>
                                <th>Nombre Medicamento</th>
                                <th>Codigo Medicamento</th>
                                <th>Fecha de diagnostico</th>
                                <th>Hora de diagnostico</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Identificacion Paciente</th>
                                <th>Nombre Paciente</th>
                                <th>Apellidos Paciente</th>
                                <th>Nombre Medico</th>
                                <th>Apellidos Medico</th>
                                <th>Especialidad Medico</th>
                                <th>Nombre Enfermedad</th>
                                <th>Sintomas Enfermedad</th>
                                <th>Nombre Medicamento</th>
                                <th>Codigo Medicamento</th>
                                <th>Fecha de diagnostico</th>
                                <th>Hora de diagnostico</th>
                            </tr>
                        </tfoot>

                        <tbody runat="server" id="tablaCitas">
                            <!-- Aquí se agregarán las filas dinámicamente -->
                        </tbody>
                    </table>
                </div>
            </div>
        </div>


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
