#define DELAY_MS 10
void setup() {
  pinMode(3, OUTPUT);
}

void loop() {
  analogWrite(3, 150);
  delay(DELAY_MS);
}
