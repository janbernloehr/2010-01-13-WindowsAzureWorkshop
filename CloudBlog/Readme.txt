Demo Source Code des Azure Workshops vom 13.01.2010 an der Uni Stuttgart.

"Installation"
- Mit dem CreateDatabase.sql Skript kann die notwendige Datenbank erstellt werden.
- In der web.config des "BlogWebRole" Projekts muss der ConnectionString zur Datenbank
  angepasst werden.

Übersicht
 "BlogEngine" : Abstraktion der Datenbank. BlogPosts können in die Datenbank gespeichert
 (PublishPost) bzw. aus der Datenbank geladen (GetPosts) werden.

 "CloudBlogService" : Referenziert alle Web/Worker Roles und hält deren Cloud Einstellungen.
 
 "BlogWebRole" : WebRole zum CloudBlog.
 - Default.aspx Zeigt alle posts
 - NewPost.aspx Ermöglicht das Veröffentlichen neuer Posts
 - /api/metaweblog.ashx Handler für die metaweblogapi.

(c) 2010 Jan-Cornelius Molnar