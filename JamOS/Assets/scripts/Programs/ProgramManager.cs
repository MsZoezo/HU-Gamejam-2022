using System;
using System.Collections.Generic;
using UnityEngine;

public class ProgramManager : MonoBehaviour
{
    #nullable enable
    private List<GameObject> programs = new();
    public bool canOpenProtectedFolder = false;

    public GameObject? Open(GameObject programPrefab, Vector2 position, string id, bool onlyOne = false)
    {
        if (onlyOne && programs.Exists(program => program.name == id)) return null;

        GameObject program = Instantiate(programPrefab, position, Quaternion.identity);
        program.transform.SetParent(transform);
        program.name = id;

        programs.Add(program);

        return program;
    }

    public void Close(GameObject program)
    {
        if (!programs.Exists(programObj => programObj == program)) return;
        programs.Remove(program);

        Destroy(program);
    }

    public GameObject? GetById(string id)
    {
        if (!programs.Exists(program => program.name == id)) return null;
        return programs.Find(program => program.name == id);
    }

    public void CloseById(string id)
    {
        if (!programs.Exists(program => program.name == id)) return;

        GameObject program = programs.Find(program => program.name == id);

        programs.Remove(program);
        Destroy(program);
    }
}
