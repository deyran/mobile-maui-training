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

``` 
   <StackLayout VerticalOptions="CenterAndExpand"
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

1. Adicione o arquivo **Usuario.cs**
2. 6:10 Implemente conforme é mostrado no código abaixo

```
public class Usuario
{
    public Guid Id { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
}
```

### 6:40 Instalação do SQLit

1. Click com direita na Solution
2. Selecionar "Gerenciar pacotes do NuGet para solução"
3. Em procurar, escrever **sqlite-net-pcl**
4. 8:17 Instalar
    https://youtu.be/ncIcqT2yre4?t=495
      
[Parte 4](curso-maui-net-p4.md)

<!--
# Curso Maui .Net
## Curso Maui .Net - Navegando para página de Cadastro - Parte 3 - Crud com Maui + Sqlite
### 3:26 Editar or arquivo EditaUsuarioPage.xaml
-->