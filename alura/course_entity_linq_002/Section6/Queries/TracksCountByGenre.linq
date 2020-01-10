<Query Kind="Expression">
  <Connection>
    <ID>d5ebd502-fc0f-4441-b898-57f3a08a6114</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>C:\Users\flavio\dev\courses\alura\course_entity_linq_002\Section6\Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad\bin\Release\netcoreapp3.1\Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad.dll</CustomAssemblyPath>
    <CustomTypeName>Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad.Context</CustomTypeName>
    <DriverData>
      <UseDbContextOptions>false</UseDbContextOptions>
    </DriverData>
  </Connection>
</Query>

from track in Tracks.AsQueryable()
group track by track.Genre.Name into groupped
select new
{
	Genre = groupped.Key,
	Tracks = groupped.Count()
}