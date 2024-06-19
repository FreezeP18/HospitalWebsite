<%@ Page Title="Dashboard de Opciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ExpedienteMedico.Dashboard" %>

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
                        <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
                    </div>
                </div>
                <!-- /.container-fluid -->

                <div class="row">
                    <div class="col-md-3" runat="server" id="cardMedicos">
                        <div class="card" style="width: auto;">
                            <img src="/Images/medicos-icon.png" class="card-img-top" alt="Medicos">
                            <div class="card-body">
                                <h5 class="card-title">Medicos</h5>
                                <p class="card-text">Administracion de Medicos.</p>
                                <a href="VistaMedicos.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3" runat="server" id="cardPacientes">
                        <div class="card" style="width: auto;">
                            <img src="/Images/pacientes-icon.png" class="card-img-top" alt="Pacientes">
                            <div class="card-body">
                                <h5 class="card-title">Pacientes</h5>
                                <p class="card-text">Administracion de Pacientes.</p>
                                <a href="VistaPacientes.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3" runat="server" id="cardEnfermedades">
                        <div class="card" style="width: auto;">
                            <img src="/Images/enfermedades-icon.png" class="card-img-top" alt="Enfermedades">
                            <div class="card-body">
                                <h5 class="card-title">Enfermedades</h5>
                                <p class="card-text">Administracion de Enfermedades.</p>
                                <a href="VistaEnfermedades.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3" runat="server" id="cardMedicamentos">
                        <div class="card" style="width: auto;">
                            <img src="/Images/medicamentos-icon.png" class="card-img-top" alt="Medicamentos">
                            <div class="card-body">
                                <h5 class="card-title">Medicamentos</h5>
                                <p class="card-text">Administracion de Medicamentos.</p>
                                <a href="VistaMedicamentos.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-3" runat="server" id="cardCitas">
                        <div class="card" style="width: auto;">
                            <img src="/Images/citas-icon.png" class="card-img-top" alt="Citas">
                            <div class="card-body">
                                <h5 class="card-title">Citas</h5>
                                <p class="card-text">Administracion de Citas.</p>
                                <a href="VistaCitas.aspx" class="btn btn-primary">Ir a modulo</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End of Main Content -->
        </div>
        <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->
</asp:Content>
