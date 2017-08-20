void setup() {
  // put your setup code here, to run once:
  pinMode(1, OUTPUT);
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  
}

void loop() {
  
  digitalWrite(1, HIGH);
  delay(500);
  digitalWrite(1, LOW);
  digitalWrite(2, HIGH);
  delay(500);
  digitalWrite(2, LOW);
  digitalWrite(3, HIGH);
  delay(500);
  digitalWrite(3, LOW);
  digitalWrite(4, HIGH);
  delay(500);
  digitalWrite(4, LOW);
  
//  digitalWrite(13, HIGH);
//  delay(500);
//  digitalWrite(13, LOW);
//  delay(250);
}
