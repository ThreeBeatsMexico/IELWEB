<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IELWEB.Startup.Login" %>

<!DOCTYPE html>

<html>
  <head>
    <meta charset="UTF-8">
    <title>IEL - Control Escolar</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.4 -->
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Font Awesome Icons -->
    <link href="../bootstrap/css/IELIcons.css" rel="stylesheet" type="text/css" />
   
       <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link href="../plugins/iCheck/square/blue.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
  </head>
  <body class="login-page">
    <div class="login-box">
        <div class="login-logo">
             <i class=" icon-LogoIELGde"></i> 
        <a href="inicio.aspx"><b>IEL</b> Control Escolar</a>
      </div><!-- /.login-logo -->


      <div class="login-box-body  bg-blue-gradient ">
        <p class="login-box-msg">Inicia Sesion</p>
        <form  id="form1" runat="server" >
          <div class="form-group has-feedback">

                  <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Usuario" ></asp:TextBox> 
          <%--  <input type="email" class="form-control" placeholder="Email"/>--%>
            <span class="glyphicon glyphicon-user form-control-feedback"></span>
          </div>
          <div class="form-group has-feedback">
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" ></asp:TextBox> 
            <%--<input type="password" class="form-control" placeholder="Password"/>--%>
            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
          </div>
          <div class="row">
            <div class="col-xs-8">    
              <div class="checkbox icheck">
                <label>
                  <input type="checkbox" class="bg-purple" id="chkPersist" runat="server"> Recuerdame
                </label>
              </div>                        
            </div><!-- /.col -->
               <div class="social-auth-links text-center">
          <p><asp:label ID="lblMensaje" runat="server"></asp:label></p>
           </div>
            <div class="col-xs-4">
                <asp:Button ID="btnEntrar"  runat="server" Text="Entrar" CssClass="btn bg-blue-active btn-block btn-flat" OnClick="btnEntrar_Click" />
       
            </div><!-- /.col -->
          </div>
        </form>

   

      </div><!-- /.login-box-body -->
    </div><!-- /.login-box -->

    <!-- jQuery 2.1.4 -->
    <script src="../plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.2 JS -->
    <script src="../bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="../plugins/iCheck/icheck.min.js" type="text/javascript"></script>
    <script>
      $(function () {
        $('input').iCheck({
          checkboxClass: 'icheckbox_square-blue',
          radioClass: 'iradio_square-blue',
          increaseArea: '20%' // optional
        });
      });
    </script>
  </body>
</html>