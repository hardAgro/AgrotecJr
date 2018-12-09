/*========================================================
  CIMATEC jr
  Equipe Agrotec jr
  Projeto Tec

  Descricao:

  Autor: Flavio Filipe dos Santos Viana

  Mentor:
  - Anthony Stark.

  Salvador, 09/10/2018
  ========================================================*/

//--------------------------------------------------------
// Inclusao das bibliotecas:
//--------------------------------------------------------
#include <math.h>
#include <Wire.h>
#include <TimerOne.h>
#include <LiquidCrystal.h>

//--------------------------------------------------------
// Definicao de Constantes:
//--------------------------------------------------------
#define TEMPO_AMOSTRA             0.001
#define PERIODO_CICLO             0.01667   // Tempo de amostra de um ciclo
#define N_CICLOS                  3.0       // Numero de Ciclos
#define TAMANHO_VETOR             50        // =(PERIODO_CICLO/TEMPO_AMOSTRA)*N_CICLOS
#define FATOR_ESCALA              1.0       // Fator de escala para umidade do solo
#define N_MEDIA_MOVEL             10

//--------------------------------------------------------
// Declaracao de Portas
//--------------------------------------------------------
const int umidade = A0;

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);

//--------------------------------------------------------
// Declaracao de Variaveis Globais:
//--------------------------------------------------------
unsigned char flagBuffReady;
int sensor1 = 10;
int sensor2 = 11;

byte seven_seg_digits[4][7] = {  { 1,1,1,1,1,1,0 },  // = Digito 0
                                 { 0,1,1,0,0,0,0 },  // = Digito 1
                                 { 1,1,0,1,1,0,1 },  // = Digito 2
                                 { 1,1,1,1,0,0,1 },  // = Digito 3
};
//--------------------------------------------------------
// Prototipos das Funcoes Utilizadas:
//--------------------------------------------------------


//--------------------------------------------------------
// Funcao de Inicializacao antes de executar o
// Loop Principal:
//--------------------------------------------------------
void setup() {
  // Inicializa todas as variaveis, vetores, perifericos e pinos;

  flagBuffReady = 0;

  //Define o número de colunas e linhas do LCD
  lcd.begin(16, 2);
  Serial.begin(9600);

  pinMode(2, OUTPUT); //Pino 2 do Arduino ligado ao segmento A  
  pinMode(3, OUTPUT); //Pino 3 do Arduino ligado ao segmento B
  pinMode(4, OUTPUT); //Pino 4 do Arduino ligado ao segmento C
  pinMode(5, OUTPUT); //Pino 5 do Arduino ligado ao segmento D
  pinMode(6, OUTPUT); //Pino 6 do Arduino ligado ao segmento E
  pinMode(7, OUTPUT); //Pino 7 do Arduino ligado ao segmento F
  pinMode(8, OUTPUT); //Pino 8 do Arduino ligado ao segmento G

  pinMode(sensor1, INPUT); //Pino 10 sensor nivel 2)
  pinMode(sensor2, INPUT); //Pino 11 sensor nivel 1)
}

void sevenSegWrite(byte digit)  //Funcao que aciona o display
{
  byte pin = 2;

  //Percorre o array ligando os segmentos correspondentes ao digito
  for (byte segCount = 0; segCount < 7; ++segCount)  
  { 
    digitalWrite(pin, seven_seg_digits[digit][segCount]);
    ++pin;
  }
    delay(100);   //Aguarda 100 milisegundos
}

int display7seg (int sen1, int sen2) {
  if(digitalRead(sen1)==0) {              //Verifica se o sensor nivel 2 está ativado
    sevenSegWrite(2);                     //Imprime variável 2 se verdadeiro
  } else {
    if(digitalRead(sen2)==0) {            //Verifica se o sensor nivel 1 está ativado
      sevenSegWrite(1);                   //Imprime variável 1 se verdadeiro
    } else {
    sevenSegWrite(0);                     //Não há corrente, imprime variável 0 no display 7seg
    }
  }
}

void loop() {
  display7seg (sensor1, sensor2);
  
}
