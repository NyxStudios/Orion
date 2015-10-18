﻿using Orion.Framework.Events;

namespace Orion.NetData.Packets
{
	/// <summary>
	/// Continue Connecting [3] packet. Sent from the server to the client.
	/// </summary>
	public class ContinueConnecting : TerrariaPacketBase
	{
		/// <summary>
		/// The player index.
		/// </summary>
		byte PlayerID { get; set; }

		/// <summary>
		/// Creates a new Continue Connecting packet.
		/// </summary>
		/// <param name="playerID">The player index.</param>
		internal ContinueConnecting(int playerID) 
			: base(PacketTypes.ContinueConnecting)
		{
			PlayerID = (byte)playerID;
		}

		/// <summary>
		/// Sets the remote client in <paramref name="e"/> to <see cref="PlayerID"/>.
		/// </summary>
		/// <param name="e">The <see cref="NetSendDataEventArgs"/> to be set.</param>
		internal override void SetNewData(ref NetSendDataEventArgs e)
		{
			e.RemoteClient = PlayerID;
		}
	}
}
