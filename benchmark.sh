echo Rate: ${RATE}
echo Duration: ${DURATION} seconds

dotnet VegetaTargetGenerator.dll ${RATE} ${DURATION} | vegeta attack -rate=${RATE} -duration=${DURATION}s -format=json -output=/results/results.bin
vegeta plot -output=/results/results.html /results/results.bin