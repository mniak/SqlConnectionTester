SQL Test
============================

Create a container to test a SQL connection

## Environment variables

### `ConnectionString`
Required.
The connection string to test.

### `Query`
Optional.
The default query is `SELECT TOP(1) 1 FROM <TableName>`.
If the `TableName` is missing, then `Query` is required.

### `TableName`
Optional.
Used only if `Query` is missing.
The table name to use in order to build a query.
Default value: `Person.Person`.

### `Delay`
Optional. Default value: `2000`.


## Example

In bash:
```bash
docker run \
  --env ConnectionString="Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;" \
  --env TableName="dbo.ExampleTable" \
  mniak/sqltest
```

In powershell:
```
docker run `
  --env ConnectionString="Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;" `
  --env TableName="dbo.ExampleTable" `
  mniak/sqltest
```