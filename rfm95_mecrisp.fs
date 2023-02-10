\ Register addresses
$01 variable RegOpMode
$06 variable RegFrMsb
$07 variable RegFrMid
$08 variable RegFrLsb
$1D variable RegModemConfig1
$1E variable RegModemConfig2
$22 variable RegPayloadLength
$0D variable RegFifoAddrPtr
$0E variable RegFifoTxBaseAddr
$0F variable RegFifoRxBaseAddr
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
  RegOpMode !
;

: set-frequency ( freq -- ) \ Set frequency
  RegFrMsb !
  RegFrMid !
  RegFrLsb !
;

: set-modem-config ( fsk-ook -- ) \ Set modem configuration
  RegModemConfig1 !
  RegModemConfig2 !
;

: set-payload-length ( length -- ) \ Set payload length
  RegPayloadLength !
;

: set-fifo-addr ( tx-base rx-base -- ) \ Set FIFO addresses
  RegFifoTxBaseAddr !
  RegFifoRxBaseAddr !
  RegFifoAddrPtr !
;

: check-rx-done ( -- flag ) \ Check if RX is done
  RegIrqFlags @
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
