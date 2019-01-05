const nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]


for (let i in nums) {
  if (i === 5) break
  console.log(nums[i])
}

for (let i in nums) {
  if (i === 5) continue
  console.log(nums[i])
}

externo: for (let i = 0; i <= 10; i++) {
  for (let j = 0; j <= 5; j++) {
    if (j === 3) break externo
    console.log(`[${i} - ${j}]`)
  }
}
