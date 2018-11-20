echo Rate: ${RATE}
echo Duration: ${DURATION} seconds

dotnet VegetaTargetGenerator.dll ${RATE} ${DURATION} | vegeta attack -rate=${RATE} -duration=${DURATION}s -format=json -output=/results/results.bin
vegeta plot /results/results.bin > /results/results.html