﻿class SysCommandConverter :
    WriteOnlyJsonConverter<SysCommand>
{
    public override void Write(VerifyJsonWriter writer, SysCommand command)
    {
        writer.WriteStartObject();
        writer.WriteMember(command, command.CommandText, "Text");
        writer.WriteMember(command, command.Parameters, "Parameters");
        writer.WriteMember(command, command.Transaction != null, "HasTransaction");

        if (command.CommandTimeout != 30)
        {
            writer.WriteMember(command, command.CommandTimeout, "Timeout");
        }

        if (command.CommandType != CommandType.Text)
        {
            writer.WriteMember(command, command.CommandType, "Type");
        }

        if (!command.DesignTimeVisible)
        {
            writer.WriteMember(command, command.DesignTimeVisible, "DesignTimeVisible");
        }

        writer.WriteMember(command, command.Notification, "Notification");

        if (command.UpdatedRowSource != UpdateRowSource.Both)
        {
            writer.WriteMember(command, command.UpdatedRowSource, "UpdatedRowSource");
        }

        writer.WriteEndObject();
    }
}