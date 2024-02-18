
#define PIN 2
void setup() {
  Serial.begin(9600);
  pinMode(PIN, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly: 
  if(digitalRead(PIN) == HIGH)
    Serial.println("1");
  else if(digitalRead(PIN) == LOW)
    Serial.println("0");
    
  delay(1000);
}
