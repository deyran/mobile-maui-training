# Curso Maui .Net

## Criando Projeto e Telas de Login - Parte 2 - Crud com Maui + Sqlite

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
<VerticalStackLayout>
    <Label 
        Text = "LOGIN"
        VerticalOptions = "Center"
        HorizontalOptions = "Center" />

    <Label Text = "E-mail" />
    <Entry Placeholder = "Digite seu E-mail" x:Name = "Email" />

    <Label Text = "Senha" />
    <Entry Placeholder = "Digite sua senha" x:Name = "Senha" />

    <Button 
        Text = "Entrar"
        x:Name = "btnEntrar" />

    <Button 
        Text = "Registrar-se"
        x:Name = "btnRegistrar"         
        Clicked = "btnRegistrar_Clicked" />
        
        <!--
        btnRegistrar
        OBS:    1. No evento Clicked, o framework já cria automaticamente o método baseando-se no nome dado ao objeto
                2. Ao colcar o cursor no método e pressionar F12, o frame work já direciona para estrutura do método   
                3. CTRL + -, ele retorna ao arquivo LoginUsuarioPage.xaml
        -->   

</VerticalStackLayout>
```

<!--
# Curso Maui .Net
## Criando Projeto e Telas de Login - Parte 2 - Crud com Maui + Sqlite
### 1:22 Editar o arquivo LoginUsuarioPage.xaml
-->

3. AAAA