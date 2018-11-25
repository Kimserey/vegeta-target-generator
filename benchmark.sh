echo Rate: ${RATE}
echo Duration: ${DURATION} seconds

dotnet VegetaTargetGeneratorCS.dll ${RATE} ${DURATION} | vegeta attack -rate=${RATE} -duration=${DURATION}s -format=json -output=/results/results.bin
vegeta plot -output=/results/results.html /results/results.bin
vegeta report -type="hist[0,20ms,40ms,60ms,80ms,100ms]" -output=/results/results.hist.txt /results/results.bin
vegeta report -output=/results/results.txt /results/results.bin