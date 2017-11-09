using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogoConnect
{
    /// <summary>
    /// Thrown when there is a communication exception between PC and LOGO
    /// </summary>
    public class LogoCommunicationException : Exception
    {
        public LogoCommunicationException(string message) : base(message)
        {
        }
    }
    public enum LogoType { Unknown, Logo0BA7, Logo0BA8, Logo8FS4}

    public class LogoConnector
    {

        protected Boolean LogoIsBigEndian = true;
        protected Sharp7.S7Client Client = new Sharp7.S7Client();
        protected LogoType Type = LogoType.Unknown;

        /// <summary>
        /// Setup a new connection
        /// </summary>
        /// <param name="type">The type of logo to connect to</param>
        public LogoConnector(LogoType type)
        {
            this.Type = type;
            // Adjust endinanness if it turns out to be different for different logos
            if(type == LogoType.Logo8FS4)
            {
                LogoIsBigEndian = true; 
            }
            else if(type == LogoType.Logo0BA8)
            {
                LogoIsBigEndian = true; 
            }
            else if (type == LogoType.Logo0BA7)
            {
                LogoIsBigEndian = true; // VERIFY THIS
            }
        }

        /// <summary>
        /// Start a new connector and setup the connection parameters
        /// </summary>
        /// <param name="type">The type of LOGO to connect to</param>
        /// <param name="ipAddress">The address of the logo</param>
        /// <param name="localTSAP">The TSAP endpoint of this machine</param>
        /// <param name="remoteTSAP">The TSAP endpoint of the LOGO (often 0x0200)</param>
        public LogoConnector(LogoType type, string ipAddress, ushort localTSAP, ushort remoteTSAP) :this(type)
        {
            SetConnectionParams(ipAddress, localTSAP, remoteTSAP);
        }


        /// <summary>
        /// Set the connection parameters
        /// </summary>
        /// <param name="ipAddress">The address of the logo</param>
        /// <param name="localTSAP">The TSAP endpoint of this machine</param>
        /// <param name="remoteTSAP">The TSAP endpoint of the LOGO (often 0x0200)</param>
        public void SetConnectionParams(string ipAddress, ushort localTSAP, ushort remoteTSAP)
        {
            Client.SetConnectionParams(ipAddress, localTSAP, remoteTSAP);
        }

        /// <summary>
        /// Ensure a connection to the LOGO
        /// </summary>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public void Connect()
        {
            int error = Client.Connect();
            if(error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }
        }

        /// <summary>
        /// Read a bit from the LOGO's VB memory
        /// </summary>
        /// <param name="address">The VB address of the byte</param>
        /// <param name="bitNr">The number of the bit to write to</param>
        /// <returns>The value of the read bit</returns>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public bool ReadVBit(int address, int bitNr)
        {
            // Make sure the input values do not exceed max
            if (bitNr > 7) { bitNr = 7; }
            if (bitNr < 0) { bitNr = 0; }
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Calculate the bit's address in bits
            int bitAddr = address * 8 + bitNr;

            // Prepare a buffer to read into
            byte[] buffer = new byte[1];

            // Read the variable
            int error = Client.ReadArea(Sharp7.S7Consts.S7AreaDB, 1, bitAddr, 1, Sharp7.S7Consts.S7WLBit, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }

            // convert read bit to boolean value and return
            return (bool)(buffer[0] > 0); 
        }

        /// <summary>
        /// Read a byte from the LOGO's VB memory
        /// </summary>
        /// <param name="address">The VB address of the byte</param>
        /// <returns>The value of the VB byte</returns>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public byte ReadVByte(int address)
        {
            // Make sure the input values do not exceed max
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Prepare a buffer to read into
            byte[] buffer = new byte[1];
            // Read the variable
            int error = Client.ReadArea(Sharp7.S7Consts.S7AreaDB, 1, address, 1, Sharp7.S7Consts.S7WLByte, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }

            // Return the read byte
            return buffer[0];
        }

        /// <summary>
        /// Read a word (2 bytes, e.g. network analog I/O) from the LOGO's VB memory
        /// </summary>
        /// <param name="address">The VW address of the word</param>
        /// <returns>The value of the VW word</returns>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public ushort ReadVWord(int address)
        {
            // Make sure the input values do not exceed max
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Prepare a buffer to read into
            byte[] buffer = new byte[2];
            // Read the variable
            int error = Client.ReadArea(Sharp7.S7Consts.S7AreaDB, 1, address, 1, Sharp7.S7Consts.S7WLWord, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }

            // Invert the buffer if the endian of the system does not match that of the LOGO
            if ((LogoIsBigEndian == BitConverter.IsLittleEndian))
            {
                Array.Reverse(buffer);
            }
            // Return the read byte
            return BitConverter.ToUInt16(buffer, 0);
        }

        /// <summary>
        /// Write bit value to the LOGO's VB Memory
        /// </summary>
        /// <param name="address">The VB address of the byte</param>
        /// <param name="bitNr">The number of the bit to write to</param>
        /// <param name="value">The value to write</param>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public void WriteVBit(int address, int bitNr, bool value)
        {
            // Make sure the input values do not exceed max
            if (bitNr > 7) { bitNr = 7; }
            if (bitNr < 0) { bitNr = 0; }
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Calculate the bit's address in bits
            int bitAddr = address * 8 + bitNr;

            // Prepare a buffer to write from
            byte[] buffer = new byte[1];

            // Set the value in the buffer according to the bit value
            if(value) { buffer[0] = 0x01; }
            else { buffer[0] = 0x00; }

            // Write the value
            int error = Client.WriteArea(Sharp7.S7Consts.S7AreaDB, 1, bitAddr, 1, Sharp7.S7Consts.S7WLBit, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }
        }

        /// <summary>
        /// Write a byte value to the LOGO's VB Memory
        /// </summary>
        /// <param name="address">The VB address of the byte </param>
        /// <param name="value">The value of the byte to write</param>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public void WriteVByte(int address, byte value)
        {
            // Make sure the input values do not exceed max
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Prepare a buffer to write from
            byte[] buffer = new byte[1];

            buffer[0] = value; 

            // Write the value
            int error = Client.WriteArea(Sharp7.S7Consts.S7AreaDB, 1, address, 1, Sharp7.S7Consts.S7WLByte, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }
        }

        /// <summary>
        /// Write a word (2 bytes, e.g. network analog I/O) value to the LOGO's VW Memory
        /// </summary>
        /// <param name="address">The VW address of the byte </param>
        /// <param name="value">The value of the byte to write</param>
        /// <exception cref="LogoCommunicationException">When there is a communications error</exception>
        public void WriteVWord(int address, ushort value)
        {
            // Make sure the input values do not exceed max
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            Connect();

            // Prepare a buffer to write from - and convert value to bytes
            
            byte[] buffer = BitConverter.GetBytes(value);

            // Invert the buffer if the endian of the system does not match that of the LOGO
            if ((LogoIsBigEndian == BitConverter.IsLittleEndian))
            {
                Array.Reverse(buffer);
            }

            // Write the value
            int error = Client.WriteArea(Sharp7.S7Consts.S7AreaDB, 1, address, 1, Sharp7.S7Consts.S7WLWord, buffer);
            // throw an exception if there is a communication error
            if (error > 0) { throw new LogoCommunicationException(Client.ErrorText(error)); }
        }

        public void Disconnect()
        {
            Client.Disconnect();

        }
    }
}
