@ECHO OFF

ECHO Packing GNaP.DependencyInjection.StructureMap
nuget pack src\GNaP.DependencyInjection.StructureMap\GNaP.DependencyInjection.StructureMap.csproj -Build -Prop Configuration=Release -Exclude gnap.ico

ECHO Packing GNaP.DependencyInjection.StructureMap.Web
nuget pack src\GNaP.DependencyInjection.StructureMap.Web\GNaP.DependencyInjection.StructureMap.Web.csproj -Build -Prop Configuration=Release -Exclude gnap.ico -IncludeReferencedProjects
