#include <avr/io.h>
#include <util/delay.h>

int main()
{
    DDRB = 0b00000001;
    PORTB = 0b00000000;

    while(1) {
        PORTB ^= 0x1;
        _delay_ms(100);
    }
    return 0;
}
