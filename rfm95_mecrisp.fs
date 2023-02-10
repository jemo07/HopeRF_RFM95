\ Register addresses
$01 constant RegOpMode
$06 constant RegFrMsb
$07 constant RegFrMid
$08 constant RegFrLsb
$1D constant RegModemConfig1
$1E constant RegModemConfig2
$22 constant RegPayloadLength
$0D constant RegFifoAddrPtr
$0E constant RegFifoTxBaseAddr
$0F constant RegFifoRxBaseAddr
$12 constant RegIrqFlags

\ Operating mode values
$00 constant ModeSleep
$80 constant ModeStdby
$81 constant ModeFskOokRxContinuous

\ Modem configuration values for FSK mode
$72 constant ModemConfig1Fsk
$74 constant ModemConfig2Fsk

\ Modem configuration values for OOK mode
$48 constant ModemConfig1Ook
$88 constant ModemConfig2Ook

\ FIFO address values
$00 constant FifoAddrTxBase
$00 constant FifoAddrRxBase

\ Interrupt flags values
$40 constant IrqFlagRxDone

: set-mode ( mode -- )  \ Set operating mode
  RegOpMode c!
;

: set-frequency ( freq -- ) \ Set frequency
  RegFrMsb c!
  RegFrMid c!
  RegFrLsb c!
;

: set-modem-config ( fsk-ook -- ) \ Set modem configuration
  RegModemConfig1 c!
  RegModemConfig2 c!
;

: set-payload-length ( length -- ) \ Set payload length
  RegPayloadLength c!
;

: set-fifo-addr ( tx-base rx-base -- ) \ Set FIFO addresses
  RegFifoTxBaseAddr c!
  RegFifoRxBaseAddr c!
  RegFifoAddrPtr c!
;

: check-rx-done ( -- flag ) \ Check if RX is done
  RegIrqFlags c@
  IrqFlagRxDone and
;

: init-fsk ( -- ) \ Initialize for FSK mode
  ModeStdby set-mode
  set-frequency
  ModemConfig1Fsk ModemConfig2Fsk set-modem-config
  set-payload-length
  FifoAddrTxBase FifoAddrRxBase set-fifo-addr
  ModeFskOokRxContinuous set-mode
;

: init-ook ( -- ) \ Initialize for OOK mode
  ModeStdby set-mode
  set-frequency
  ModemConfig1Ook ModemConfig2Ook set-modem-config
  set-payload-length
  FifoAddrTxBase FifoAddrRxBase set-fifo-addr
  ModeFskOokRxContinuous set-mode
;
