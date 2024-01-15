”
{C:\Desenvolvimento\Repos\dotnet-generic-importer\backend\src\Something.Infra.CrossCutting.IoC\NativeInjectorBootStrapper.cs
	namespace 	
	Something
 
. 
Infra 
. 
CrossCutting &
.& '
IoC' *
{ 
public 

static 
class &
NativeInjectorBootStrapper 2
{ 
public 
static 
void 
RegisterServices +
(+ ,
IServiceCollection, >
services? G
)G H
{ 	
services 
. 
	AddScoped 
< 
IMediatorHandler /
,/ 0
MediatorHandler1 @
>@ A
(A B
)B C
;C D
services 
. 
	AddScoped 
<  
INotificationHandler 3
<3 4
DomainNotification4 F
>F G
,G H%
DomainNotificationHandlerI b
>b c
(c d
)d e
;e f
services   
.   
	AddScoped   
<   !
IImportFieldRetriever   4
,  4 5 
ImportFieldRetriever  6 J
>  J K
(  K L
)  L M
;  M N
services## 
.## 
	AddScoped## 
<## 
IRequestHandler## .
<##. /
AddXptoCommand##/ =
,##= >
Unit##? C
>##C D
,##D E
XptoCommandHandler##F X
>##X Y
(##Y Z
)##Z [
;##[ \
services$$ 
.$$ 
	AddScoped$$ 
<$$ 
IRequestHandler$$ .
<$$. /"
AddImportLayoutCommand$$/ E
,$$E F
Unit$$G K
>$$K L
,$$L M&
ImportLayoutCommandHandler$$N h
>$$h i
($$i j
)$$j k
;$$k l
services%% 
.%% 
	AddScoped%% 
<%% 
IRequestHandler%% .
<%%. /
AddImportCommand%%/ ?
,%%? @
Unit%%A E
>%%E F
,%%F G 
ImportCommandHandler%%H \
>%%\ ]
(%%] ^
)%%^ _
;%%_ `
services(( 
.(( 
	AddScoped(( 
<((  
INotificationHandler(( 3
<((3 4
ImportAddedEvent((4 D
>((D E
,((E F
ImportAppService((G W
>((W X
(((X Y
)((Y Z
;((Z [
services++ 
.++ 
	AddScoped++ 
<++ 
DataContext++ *
>++* +
(+++ ,
)++, -
;++- .
services.. 
... 
	AddScoped.. 
<.. 
IXptoRepository.. .
,... /
XptoRepository..0 >
>..> ?
(..? @
)..@ A
;..A B
services// 
.// 
	AddScoped// 
<// #
IImportLayoutRepository// 6
,//6 7"
ImportLayoutRepository//8 N
>//N O
(//O P
)//P Q
;//Q R
services00 
.00 
	AddScoped00 
<00 
IImportRepository00 0
,000 1
ImportRepository002 B
>00B C
(00C D
)00D E
;00E F
services33 
.33 
	AddScoped33 
<33 
IXptoAppService33 .
,33. /
XptoAppService330 >
>33> ?
(33? @
)33@ A
;33A B
services44 
.44 
	AddScoped44 
<44 #
IImportLayoutAppService44 6
,446 7"
ImportLayoutAppService448 N
>44N O
(44O P
)44P Q
;44Q R
services55 
.55 
	AddScoped55 
<55 
IImportAppService55 0
,550 1
ImportAppService552 B
>55B C
(55C D
)55D E
;55E F
}77 	
}88 
}99 