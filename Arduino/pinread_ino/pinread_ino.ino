#define DELAY_MS 500
#define BUTTON 7
#define LED 3

void setup() {
  pinMode(LED, OUTPUT);
  pinMode(BUTTON, INPUT);
}

void loop() {
  if (digitalRead(BUTTON) == HIGH) {
    digitalWrite(LED, HIGH);
  //  delay(DELAY_MS);
  }
 else if (digitalRead(BUTTON) == LOW) {
    digitalWrite(LED, LOW);
  //  delay(DELAY_MS);
  } 
}
