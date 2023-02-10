# HopeRF RFM95 Driver in Forth

This code provides a Forth driver for the HopeRF RFM95 module. The driver allows you to configure the module in either FSK or OOK mode and receive data via SPI.

## Getting Started

Here are the steps to get started with using the RFM95 driver in Forth:

1. Make sure you have the necessary hardware components, including the HopeRF RFM95 module, an appropriate microcontroller, and a means of communicating with the module over SPI.
2. Clone this repository or download the Forth driver code.
3. Open the code in a Forth environment and compile the code.
4. Initialize the HopeRF RFM95 module for either FSK or OOK mode using the ***init-fsk*** or ***init-ook*** word, respectively.
5. Set the operating frequency using the ***set-frequency*** word.
6. Configure the modem using the ***set-modem-config*** word.
7. Set the payload length using the ***set-payload-length*** word.
8. Set the FIFO addresses using the ***set-fifo-addr*** word.
9. Put the module in receive mode by calling the ***set-mode*** word with ***ModeFskOokRxContinuous***.
10. Check if the receiver has received any data by calling the ***check-rx-done*** word.

## Contributing

If you would like to contribute to the development of this driver, please fork the repository and submit a pull request.

## Acknowledgments

The code in this repository was inspired by the HopeRF RFM95 datasheet. 
