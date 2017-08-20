#define DELAY_MS 5
void setup() {
  pinMode(3, OUTPUT);
}

void loop() {
  int i = 1;
  for (i = 1; i <= 255; i++){
    analogWrite(3, i);
    delay(DELAY_MS);
  }
  delay(100*DELAY_MS);
  for (i = 256; i >= 1; i--){
    analogWrite(3, i);
    delay(DELAY_MS);
  }
  delay(100*DELAY_MS);
}
