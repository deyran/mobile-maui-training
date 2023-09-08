# Curso Maui .Net

## [Curso Maui .Net - Navegando para página de Cadastro - Parte 3 - Crud com Maui + Sqlite](https://youtu.be/ncIcqT2yre4?si=EmyhXFD_iq_jn0s0)

### 00:22 Navegação entre telas

1. Abra o **arquivo App.xaml.cs**, edite conforme o código abaixo:
   
   ```
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUsuarioPage());
        }

   ```

2. Abra o arquivo **LoginUsuarioPage.xmal**, no metodo **BtnRegistrar_Clicked**, pressione F12
3. No método **BtnRegistrar_Clicked** digite o seguite código:
   
   ```
   Navigation.PushAsync(new EditaUsuarioPage());
   ```

### 3:26 Editar or arquivo EditaUsuarioPage.xaml

```    <StackLayout    VerticalOptions="CenterAndExpand"
                    Margin="16"
                    Padding="16">

        <Label Text="E-mail" x:Name="lblEmail" />
        <Entry Placeholder="Digite seu e-mail" x:Name="txtEmail" />

        <Label Text="Senha" x:Name="lblSenha" />
        <Entry Placeholder="Digite sua Senha" x:Name="txtSenha" />

        <Button 
            Text="Cadastrar"
            x:Name="btnCadastrar"
            CLicked = "btnCadastrar_CLiked"
            Margin="10" />

    </StackLayout>
```

### 5:22 Model

https://youtu.be/ncIcqT2yre4?t=321

[Parte 4](curso-maui-net-p3.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 3 - Crud com Maui + Sqlite
### 5:22 Model
-->