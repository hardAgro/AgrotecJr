#include <ESP8266WiFi.h>//Biblioteca que gerencia o WiFi.
#include <WiFiServer.h>//Biblioteca que gerencia o uso do TCP.


WiFiServer servidor(80);//Cria um objeto "servidor" na porta 80 (http).
WiFiClient cliente;//Cria um objeto "cliente".

const int D4 = 4;
const int D5 = 5;
const int D6 = 6;

String html;//String que armazena o corpo do site.

 
void setup()
{
   Serial.begin(9600);//Inicia comunicaÃ§ao Serial.
 
   WiFi.mode(WIFI_STA);//Habilita o modo STATION.
   WiFi.begin("agrotec", "123");//Conecta no WiFi (COLOQUE O NOME E SENHA DA SUA REDE!).
 
   Serial.println(WiFi.localIP());//Printa o IP que foi consebido ao ESP8266.
   servidor.begin();//Inicia o Servidor.
 
   pinMode(D4, OUTPUT);   //Define o LED_BUILTIN como Saida.
   pinMode(D5, INPUT);    //Porta de leitura do sensor de nÃ­vel 2.
   pinMode(D6, INPUT);    //Porta de leitura do sensor de nÃ­vel 1.
}
 
void loop()
{
   http();//Sub rotina para verificaÃ§ao de clientes conectados.
}
 
void http()//Sub rotina que verifica novos clientes e se sim, envia o HTML.
{
   cliente = servidor.available();//Diz ao cliente que hÃ¡ um servidor disponivel.
 
   if (cliente == true)//Se houver clientes conectados, ira enviar o HTML.
   {
      String req = cliente.readStringUntil('\r');//Faz a leitura do Cliente.
      Serial.println(req);//Printa o pedido no Serial monitor.
 
      if (req.indexOf("/LED") > -1)//Caso o pedido houver led, inverter o seu estado.
         
      html = "";//Reseta a string.
      html += "HTTP/1.1 Content-Type: text/html\n\n";//IdentificaÃ§ao do HTML.
      html += "<!DOCTYPE html><html><head><title>ESP8266 WEB</title>";//IdentificaÃ§ao e Titulo.
      html += "<meta name='viewport' content='user-scalable=no'>";//Desabilita o Zoom.
      html += "<style>h1{font-size:2vw;color:black;}</style></head>";//Cria uma nova fonte de tamanho e cor X.
      html += "<body bgcolor='ffffff'><center><h1>";//Cor do Background
 
      //Estas linhas acima sao parte essencial do codigo, sÃ³ altere se souber o que esta fazendo!
 
      html += "<form action='/LED' method='get'>";//Cria um botao GET para o link /LED
      html += "<input type='submit' value='LED' id='frm1_submit'/></form>";
      
      html += "</h1></center></body></html>";//Termino e fechamento de TAG`s do HTML. Nao altere nada sem saber!
      cliente.print(html);//Finalmente, enviamos o HTML para o cliente.
      if(digitalRead(D5)==0) {
        cliente.print("2");
      } else if ((digitalRead(D6)==0)){
        cliente.print("1");
      } else {
        cliente.print("0");
      }
      cliente.stop();//Encerra a conexao.
   }
}
