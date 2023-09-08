# Curso Maui .Net

## [Criando Projeto e Telas de Login - Parte 2 - Crud com Maui + Sqlite](https://youtu.be/63MrN1hjOdM?si=pH583ad6nYIKVVbR)

### 0:25 Visualisar tela de Login

1. App.xaml
2. Duplo clique App.xaml.cs
3. Mudar de **AppShell()** para **LoginUsuarioPage()**
4. CTRL + . para adicionar **using OficinaApp.Pages**
5. Salvar e **CTRL + SHIFT + F5** para reiniciar o emulador

### 1:22 Editar o arquivo LoginUsuarioPage.xaml

1. Duplo clique em **LoginUsuarioPage.xaml**
2. Editar o arquivo para seguinte conteúdo:

```
<StackLayout    VerticalOptions="CenterAndExpand"
                Margin="16"
                Padding="16">
    <Label 
        Text = "LOGIN"
        VerticalOptions = "Center"
        HorizontalOptions = "Center" />

    <Label Text = "E-mail" x:Name = "lblName" />
    <Entry Placeholder = "Digite seu E-mail" x:Name = "txtEmail" />

    <Label Text = "Senha" x:Name = "lblSenha" />
    <Entry Placeholder = "Digite sua senha" x:Name = "txtSenha" />

    <Button 
        Text = "Entrar"
        x:Name = "btnEntrar"
        Clicked = "btnEntrar_Cliked"
        Margin="10" />

    <Button 
        Text = "Registrar-se"
        x:Name = "btnRegistrar"         
        Clicked = "btnRegistrar_Clicked"
        Margin="10" />
        
        <!--
        btnRegistrar
        OBS:    1. No evento Clicked, o framework já cria automaticamente o método baseando-se no nome dado ao objeto
                2. Ao colcar o cursor no método e pressionar F12, o frame work já direciona para estrutura do método   
                3. CTRL + -, ele retorna ao arquivo LoginUsuarioPage.xaml
        -->   

</StackLayout>
```

<!--
# Curso Maui .Net
## Criando Projeto e Telas de Login - Parte 2 - Crud com Maui + Sqlite
### 0:25 Visualisar tela de Login
-->