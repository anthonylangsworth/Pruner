﻿using CsvHelper;
using System.Globalization;
using Pruner;

IList<DiscordMember> GetDiscordMembers()
{
    using StreamReader streamReader = new StreamReader("discord-members.csv");
    using CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
    csvReader.Context.RegisterClassMap<DiscordMemberMap>();
    return csvReader.GetRecords<DiscordMember>().ToList();
}

IList<SquadronMember> GetSquadronMembers()
{
    using StreamReader streamReader = new StreamReader("squadron-members.csv");
    using CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
    csvReader.Context.RegisterClassMap<SquadronMemberMap>();
    return csvReader.GetRecords<SquadronMember>().ToList();
}

IList<DiscordMember> discordMembers = GetDiscordMembers();
IList<SquadronMember> squadronMembers = GetSquadronMembers();

foreach(string name in squadronMembers.Where(sm => discordMembers.Any(dm => sm.Name == dm.Name)).Select(sm => sm.Name))
{
    Console.WriteLine(name);
}