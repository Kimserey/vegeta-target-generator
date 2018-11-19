echo Rate: ${RATE}
echo Duration: ${DURATION} seconds

dotnet VegetaTargetGenerator.dll ${RATE} ${DURATION} | vegeta attack -rate=${RATE} -duration=${DURATION}s -format=json > results.bin
vegeta plot results.bin > ./results/results.html