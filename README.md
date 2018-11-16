# Vegeta Target Generator Example

This is an example of a target generator example for [`vegeta` load test](https://github.com/tsenart/vegeta). 
It uses `FsCheck` to generate arbitrary data and construct a target for `vegeta`.

## How to use it

1. Download `vegeta` from the repository release
2. Place it in `C:\Tools\vegeta\` (that's the path used in `run.cmd`)
3. Run the `TestWebServer` - it has an endpoint on `POST http://localhost:5000/Persons`
4. Run `run.cmd [request per second] [duration in seconds]` for example `run.cmd 10 60` for 10 requests per seconds for 60 seconds
5. Open `results.html` in browser