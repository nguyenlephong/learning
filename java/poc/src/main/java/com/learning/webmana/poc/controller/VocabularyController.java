package com.learning.webmana.poc.controller;

import com.learning.webmana.poc.model.Vocabulary;
import com.learning.webmana.poc.service.VocabularyService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/vocabulary")
public class VocabularyController {
    private final VocabularyService vocabularyService;

    public VocabularyController(VocabularyService vocabularyService) {
        this.vocabularyService = vocabularyService;
    }

    @GetMapping
    public List<Vocabulary> getAllWords() {
        return vocabularyService.getAllWords();
    }

    @PostMapping
    public ResponseEntity<Vocabulary> addWord(@RequestBody Vocabulary vocabulary) {
        return ResponseEntity.ok(vocabularyService.addWord(vocabulary));
    }

    @PutMapping("/{word}")
    public ResponseEntity<Vocabulary> updateWord(@PathVariable String word, @RequestBody Vocabulary updatedVocabulary) {
        Vocabulary updated = vocabularyService.updateWord(word, updatedVocabulary);
        return (updated != null) ? ResponseEntity.ok(updated) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{word}")
    public ResponseEntity<String> deleteWord(@PathVariable String word) {
        return vocabularyService.deleteWord(word)
                ? ResponseEntity.ok("Deleted successfully")
                : ResponseEntity.notFound().build();
    }
}