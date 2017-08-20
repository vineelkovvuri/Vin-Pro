#define DELAY_MS 1000
void setup() {
  Serial.begin(9600);  
  //analogReference(EXTERNAL);

}

void loop() {
    int v = analogRead(0);
  Serial.println(v*.0049); 
  delay(DELAY_MS);
}
