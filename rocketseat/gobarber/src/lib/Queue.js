import Bee from 'bee-queue'
import CancellationMail from '../app/jobs/CancellationMail'
import redisConfig from '../config/redis'

const jobs = [CancellationMail]

class Queue {
  constructor() {
    this.queues = {}

    this.init()
  }

  init() {
    jobs.forEach((job) => {
      this.queues[job.key] = new Bee(job.key, { redis: redisConfig })
    })
  }

  add(queue, data) {
    return this.queues[queue].createJob(data).save()
  }

  processQueue() {
    jobs.forEach((job) => {
      this.queues[job.key].process(job.handle)
    })
  }
}

export default new Queue()
