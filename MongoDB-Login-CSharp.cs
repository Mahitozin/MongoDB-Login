using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.Json;

var client = new MongoClient("LINK DO MONGODB");
var database = client.GetDatabase("DATABASE"); 
var usersCollection = database.GetCollection<BsonDocument>("COLLECTION"); 

string nome = input("Usuario: ");
string senha = input("Senha: ");

bool login_status = login(nome, senha); //Verifica se o nome e senha existe no MongoDB
Console.WriteLine(login_status); //Escreve o resultado da tentativa de login

Console.ReadLine(); //ReadLine para o console nao fechar sozinho
string input(string x)
{
    Console.Write(x);
    return Console.ReadLine(); //Retorna oque a pessoa digitar
}
bool login(string usr, string pass) //Metodo para verificar o usuario e senha digitado
{
    var filtro = Builders<BsonDocument>.Filter.Eq("Usuario", usr); //Coloca um filtro aonde o nome do usuario tem que ser igual ao digitado
    var usuario = usersCollection.Find(filtro).FirstOrDefault(); //Pega o primeiro item que retorna

    if (usuario != null && usuario["Senha"] == pass) //Verifica se o usuario nao e nullo e contem a mesma senha digitada
        return true;  //Sucesso ao verificar o login
    else
        return false; //Falha ao verificar o login
}

//Classe com as variaveis do usuario
class Usuario_Class
{
    ObjectId Id { get; set; }
    string Usuario { get; set; }
    string Senha { get; set; }
}
