using System;
using System.Collections.Generic;
using System.IO;
using k8s;
using k8s.Models;
using Microsoft.Extensions.Configuration;

namespace job.starter
{
    public class Job : IJob
    {
        readonly IConfiguration _configuration;
        readonly Kubernetes _kubernetes;

        public Job(IConfiguration configuration, Kubernetes kubernetes)
        {
            _configuration = configuration;
            _kubernetes = kubernetes;
        }

        public string StartAsync(string message)
        {
            string fichierYaml = _configuration["YAML"];

            string YAML = File.ReadAllText(fichierYaml);

            YAML = string.Format(YAML, message);

            var typeMap = new Dictionary<String, Type>();
            typeMap.Add("batch/v1/Job", typeof(V1Job));

            var objects = Yaml.LoadAllFromString(YAML, typeMap);

            var job = _kubernetes.CreateNamespacedJob((V1Job)objects[0], "default");

            return "";
        }
    }
}
