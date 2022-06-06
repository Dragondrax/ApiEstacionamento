<h1> API ESTACIONAMENTO RESERVE PARK</h1>
<hr />

<h3> Instruções </h3>
<p> Bom inicialmente, você terá que ter o C# ASP.NET CORE 6.0 instalado na sua máquina, para fazer a instalação. Basta clicar no link abaixo </p> 
<br/>

https://dotnet.microsoft.com/en-us/download/dotnet/6.0
<br/>

<p> Posteriormente você precisara dar o comando: 
  git clone https://github.com/Dragondrax/ApiEstacionamento.git 
  
 em uma pasta no seu computador, para você conseguir fazer isso. Você tem que ter o git instalado em sua máquina. </p>
<br/>

https://git-scm.com/downloads
<br/>

<p> Legal agora temos o nosso projeto pronto para ser inicializado, porém ainda é necessário que você instale o  SQL SERVER MANAGAMENT STUDIO E SQL SERVER EXPRESS </p>
<br />

https://aka.ms/ssmsfullsetup
https://go.microsoft.com/fwlink/?linkid=866658

<p> Olha que legal, agora ja temos o nosso banco de dados configurado, lembre-se que é necessário que vc habilite o usuário SA e salve a senha que você configurar nele ok? </p>

<p> Agora estamos com a base do projeto pronto, abra o projeto no seu visual studio. Procure o arquivo appsettings.json e altere o Data Source=SEU COMPUTADOR; PASSWORD=SUA SENHA; User Id=sa </p>

Posteriormente a isso abra o seu Sql Server Managament Studio, crie uma nova consulta e exexute o script abaixo:

CREATE DATABASE Estacionamento;

Após isso retorne para o seu Visual Studio, vá no menu "Ferramentas -> Gerenciador de Pacotes do Nuget -> Console do Gerenciador de Pacotes"

Agora execute o comando: Update-Database

Agora pronto, só rodar a aplicação e fazer suas consultas e cadastros...

Lembrando que para cadastrar um usuário é necessário que siga os passos:

1. Cadastre o usuário
2. Cadastre a carteira do usuário
3. Cadastre um veiculo para o usuário

