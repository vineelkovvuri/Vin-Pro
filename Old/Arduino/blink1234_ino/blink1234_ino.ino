#define N_PINS 4
#define DELAY_MS 250
void setup() {
  int i = 0;
  for (i = 1; i <= N_PINS; i++)
    pinMode(i, OUTPUT);
}

void loop() {
  int i = 0;
  for (i = 1; i <= N_PINS; i++){
    digitalWrite(i, HIGH);
    delay(DELAY_MS);
    digitalWrite(i, LOW);
  }
}
