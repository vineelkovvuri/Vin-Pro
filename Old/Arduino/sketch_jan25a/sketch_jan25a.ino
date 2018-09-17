#define PIN 8
void setup() {
  pinMode(PIN, OUTPUT);

}

void loop() {

  digitalWrite(PIN, HIGH);
  delay(200);
  digitalWrite(PIN, LOW);
  delay(200);
}

